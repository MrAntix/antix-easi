'use strict';

angular.module('antix.easi.examiners.edit', [
        'antix.easi.examiners.api',
        'antix.form.confirm'
])
    .controller(
        'AntixEASIExaminersEditController',
        [
            '$log', '$scope', '$state', '$stateParams',
            'ExaminersApi', 'ExaminerEvents',
            function (
                $log, $scope, $state, $stateParams,
                ExaminersApi, ExaminerEvents) {

                $log.debug('AntixEASIExaminersEditController init ' + $stateParams.id);

                ExaminersApi
                    .read({ id: $stateParams.id }).$promise
                    .then(function (data) {
                        $scope.data = data;
                    });

                $scope.update = function () {
                    $log.debug('AntixEASIExaminersEditController update ' + $scope.data.id);

                    ExaminersApi
                        .update($scope.data).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ExaminerEvents.Updated, $scope.data);

                        });
                };

                $scope.delete = function () {
                    $log.debug('AntixEASIExaminersEditController delete ' + $scope.data.id);

                    ExaminersApi
                        .delete({ id: $scope.data.id }).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ExaminerEvents.Deleted, $scope.data);
                            $state.go('examiners-index');
                        });

                };
            }
        ]);