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

                $scope.data = {};

                $scope.create = function () {

                    CliniciansApi
                        .create($scope.data).$promise
                        .then(function (data, x, y) {

                            $scope.$root.$broadcast(ClinicianEvents.Created, data);
                            $state.go('clinicians-edit', { id: data.id });
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