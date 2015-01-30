'use strict';

angular.module('antix.easi.patients.create', [
        'antix.easi.patients.api'
])
    .controller(
        'AntixEASIPatientsCreateController',
        [
            '$log', '$scope', '$state',
            'PatientsApi', 'PatientEvents',
            function (
                $log, $scope, $state,
                PatientsApi, PatientEvents) {

                $log.debug('AntixEASIPatientsCreateController init');

                $scope.data = {};

                $scope.create = function () {

                    PatientsApi
                        .create($scope.data).$promise
                        .then(function (data) {

                            $scope.$root.$broadcast(PatientEvents.Created, data);
                            $state.go('patients-edit', { id: data.id });
                        })
                        .catch(function (e) {
                            $log.debug('AntixEASIPatientsCreateController create invalid ' + JSON.stringify(e.data));

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