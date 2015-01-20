'use strict';

angular.module('antix.easi.patients.index', [
        'antix.easi.patients.list',
        'antix.easi.patients.api'
    ])
    .controller(
        'AntixEASIPatientsIndexController',
        [
            '$log', '$scope',
            'PatientsApi', 'SearchBoxEvents',
            function(
                $log, $scope,
                PatientsApi, SearchBoxEvents) {

                $log.debug('AntixEASIPatientsIndexController init');

                var search = function (e, criteria) {

                    criteria = criteria || {};
                    $log.debug('AntixEASIPatientsIndexController search(' + JSON.stringify(criteria) + ")");

                    PatientsApi.lookup({
                            text: criteria.text
                        }).$promise
                        .then(function(data) {
                            $scope.patients = data;
                        });
                };

                search();

                $scope.$root.$on(SearchBoxEvents.Search, search);
            }
        ]);