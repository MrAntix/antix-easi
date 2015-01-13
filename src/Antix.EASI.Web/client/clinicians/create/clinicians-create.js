'use strict';

angular.module('antix.easi.clinicians.create', [
        'antix.easi.clinicians.api'
])
    .controller(
        'AntixEASICliniciansCreateController',
        [
            '$log', '$scope', '$state',
            'CliniciansApi', 'ClinicianEvents',
            function (
                $log, $scope, $state,
                CliniciansApi, ClinicianEvents) {

                $log.debug('AntixEASICliniciansCreateController init');

                $scope.clinician = {};

                $scope.create = function () {

                    CliniciansApi
                        .create($scope.clinician).$promise
                        .then(function (data) {

                            $scope.$root.$broadcast(ClinicianEvents.Created, data);
                            $state.go('home');
                        })
                        .catch(function (e) {
                            $log.debug('AntixEASICliniciansCreateController create invalid ' + JSON.stringify(e.data));

                            angular.forEach(e.data, function (error) {
                                var split = error.split(':'),
                                    key = split[0][0].toLowerCase() + split[0].slice(1),
                                    validationType = split[1];

                                $log.debug('invalid ' + key + ":" + validationType);

                                $scope.form[key].$setValidity(validationType, false);
                            });
                        });
                };
            }
        ]);