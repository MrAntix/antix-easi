'use strict';

angular.module('antix.easi.patients.edit', [
        'antix.easi.patients.api',
        'antix.form.confirm'
])
    .controller(
        'AntixEASIPatientsEditController',
        [
            '$log', '$scope', '$state', '$stateParams',
            'PatientsApi', 'PatientEvents',
            function (
                $log, $scope, $state, $stateParams,
                PatientsApi, PatientEvents) {

                $log.debug('AntixEASIPatientsEditController init ' + $stateParams.id);

                PatientsApi
                    .read({ id: $stateParams.id }).$promise
                    .then(function (data) {
                        $scope.data = data;
                    });

                $scope.update = function () {
                    $log.debug('AntixEASIPatientsEditController update ' + $scope.data.id);

                    PatientsApi
                        .update($scope.data).$promise
                        .then(function () {

                            $scope.$root.$broadcast(PatientEvents.Updated, $scope.data);

                        });
                };

                $scope.delete = function () {
                    $log.debug('AntixEASIPatientsEditController delete ' + $scope.data.id);

                    PatientsApi
                        .delete({ id: $scope.data.id }).$promise
                        .then(function () {

                            $scope.$root.$broadcast(PatientEvents.Deleted, $scope.data);
                            $state.go('home');
                        });

                };
            }
        ]);