﻿'use strict';

angular.module('antix.easi.patients.select', [
        'antix.easi.patients.api'
])
    .directive(
        'patientsSelect',
        [
            '$log',
            'PatientsApi',
            function (
                $log,
                PatientsApi) {

                $log.debug('patientsSelect init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'patients/select/patients-select.cshtml',
                    scope: {
                        'patient': '='
                    },
                    link: function($scope, element, attrs) {
                        $log.debug('patientsSelect link');

                        $scope.get = function(filter) {
                            return PatientsApi.lookup({
                                    filter: filter,
                                    limitTo: 8
                                }).$promise
                                .then(function(data) {
                                    $log.debug('patientsSelect lookup ' + JSON.stringify(data));

                                    return data;
                                });
                        }
                    }
                };
            }
        ]);