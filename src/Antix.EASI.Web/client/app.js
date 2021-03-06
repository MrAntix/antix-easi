﻿'use strict';

var app = angular.module('antix.easi', [
    'ngAnimate',
    'ngCookies',
    'ngSanitize',
    'ui.bootstrap',
    'ui.router',
    'ui.utils',
    'antix.easi.searchBox',
    'antix.easi.home',
    'antix.easi.examinations',
    'antix.easi.examiners',
    'antix.easi.patients',
    'antix.status',
    'antix.form'
]);

app
    .config([
        '$stateProvider', '$urlRouterProvider',
        function (
            $stateProvider, $urlRouterProvider
            ) {

            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/client/home/home.cshtml',
                    controller: 'AntixEASIHomeController'
                });

        }
    ])
    .controller(
        'AppController',
        [
            '$log', '$scope', '$state',
            function (
                $log, $scope, $state
                ) {

                $log.debug('AppController init');

            }
        ])
    .factory('appHttpInterceptor', [
        '$log', '$injector', '$rootScope', '$q',
        'AntixStatusEvents',
        function (
            $log, $injector, $rootScope, $q,
            AntixStatusEvents
            ) {
            return {
                request: function (config) {

                    $rootScope.$broadcast(AntixStatusEvents.Spin);

                    return config;
                },
                response: function (r) {

                    $rootScope.$broadcast(AntixStatusEvents.Unspin);

                    return r;
                },
                responseError: function (rejection) {
                    $log.debug('appHttpInterceptor.responseError '
                        + rejection.status + ' '
                        + (rejection.config ? rejection.config.url : ''));

                    $rootScope.$broadcast(AntixStatusEvents.Unspin);

                    if (rejection.status) {

                        switch (rejection.status) {
                            default:
                                break;
                            case 401:

                                break;
                            case 403:
                                $rootScope.$broadcast(AntixStatusEvents.Status, { type: 'error', message: 'permission denied' });
                                break;
                            case 404:
                            case 406:
                            case 500:
                                $rootScope.$broadcast(AntixStatusEvents.Status, { type: 'error', message: 'an error occurred' });
                                break;
                        }
                    }

                    return $q.reject(rejection);
                }
            };
        }
    ])
    .config([
        '$httpProvider', function ($httpProvider) {

            $httpProvider.interceptors.push('appHttpInterceptor');
        }
    ])
    .filter('personAge', [
        function () {
            return function (model) {
                return new Date().getFullYear() - new Date(model.dateOfBirth).getFullYear();
            };
        }
    ]);