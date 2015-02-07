'use strict';

angular.module('antix.easi.examinations.edit', [
        'antix.easi.examinations.api',
        'antix.easi.examinations.regionScore',
        'antix.easi.examinations.eric',
        'antix.form.confirm'
])
    .controller(
        'AntixEASIExaminationsEditController',
        [
            '$log', '$scope', '$state', '$stateParams',
            'ExaminationsApi', 'ExaminationEvents',
            function (
                $log, $scope, $state, $stateParams,
                ExaminationsApi, ExaminationEvents) {

                $log.debug('AntixEASIExaminationsEditController init ' + $stateParams.id);

                ExaminationsApi
                    .read({ id: $stateParams.id }).$promise
                    .then(function (data) {
                        $scope.data = data;
                    });

                $scope.update = function () {
                    $log.debug('AntixEASIExaminationsEditController update ' + $scope.data.id);

                    ExaminationsApi
                        .update($scope.data).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ExaminationEvents.Updated, $scope.data);

                        });
                };

                $scope.delete = function () {
                    $log.debug('AntixEASIExaminationsEditController delete ' + $scope.data.id);

                    ExaminationsApi
                        .delete({ id: $scope.data.id }).$promise
                        .then(function () {

                            $scope.$root.$broadcast(ExaminationEvents.Deleted, $scope.data);
                            $state.go('home');
                        });
                };

                $scope.region = function (selectedName) {
                    $scope.eric.active = selectedName;
                };

                var calcRegionScore = function (region) {
                    if (region.erthema === null
                        || region.edemaPapulation === null
                        || region.excoriation === null
                        || region.lichenification === null
                        || region.area === null) return null;

                    return Math.round(
                        (region.erthema
                            + region.edemaPapulation
                            + region.excoriation
                            + region.lichenification) * region.area
                        / 7.2);
                }

                $scope.eric = {
                    head: function () {
                        return $scope.score = calcRegionScore($scope.data.headNeck);
                    },
                    trunk: function () {
                        return $scope.score = calcRegionScore($scope.data.trunk);
                    },
                    arms: function () {
                        return $scope.score = calcRegionScore($scope.data.upperExtremities);
                    },
                    legs: function () {
                        return $scope.score = calcRegionScore($scope.data.lowerExtremities);
                    }
                };
            }
        ]);