'use strict';

angular.module('antix.easi.clinicians.edit', [
        'antix.easi.clinicians.api',
        'antix.form.confirm'
])
    .controller(
        'AntixEASICliniciansEditController',
        [
            '$log', '$scope', '$state', '$stateParams',
            'CliniciansApi', 'ClinicianEvents',
            function (
                $log, $scope, $state, $stateParams,
                CliniciansApi, ClinicianEvents) {

                $log.debug('AntixEASICliniciansEditController init ' + $stateParams.id);

                CliniciansApi
                    .read({ id: $stateParams.id }).$promise
                    .then(function (data) {
                        $scope.data = data;
                    });

                $scope.update = function () {
                    $log.debug('AntixEASICliniciansEditController update ' + $scope.data.id);

                    CliniciansApi
                        .update($scope.data).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ClinicianEvents.Updated, $scope.data);

                        });
                };

                $scope.delete = function () {
                    $log.debug('AntixEASICliniciansEditController delete ' + $scope.data.id);

                    CliniciansApi
                        .delete({ id: $scope.data.id }).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ClinicianEvents.Deleted, $scope.data);
                            $state.go('home');
                        });

                };
            }
        ]);