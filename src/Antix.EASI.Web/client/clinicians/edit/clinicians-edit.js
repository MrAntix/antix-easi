'use strict';

angular.module('antix.easi.clinicians.edit', [
        'antix.easi.clinicians.api'
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

                }
            }
        ]);