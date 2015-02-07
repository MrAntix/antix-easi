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

                var regionIsValid = function(region) {
                        return (region.erthema !== null
                            && region.edemaPapulation !== null
                            && region.excoriation !== null
                            && region.lichenification !== null
                            && region.area !== null);
                    },
                    regionsAreValid = function(data) {
                        return data
                            && regionIsValid(data.headNeck)
                            && regionIsValid(data.trunk)
                            && regionIsValid(data.upperExtremities)
                            && regionIsValid(data.lowerExtremities);
                    },
                    calcRegionScore = function(region) {
                        return (region.erthema
                            + region.edemaPapulation
                            + region.excoriation
                            + region.lichenification) * region.area;
                    },
                    calcRegionScorePercent = function(data, regionName) {

                        return data && regionIsValid(data[regionName])
                            ? Math.round(calcRegionScore(data[regionName]) / 7.2)
                            : null;
                    };

                $scope.eric = {
                    head: function () {
                        return calcRegionScorePercent($scope.data,'headNeck');
                    },
                    trunk: function () {
                        return calcRegionScorePercent($scope.data, 'trunk');
                    },
                    arms: function () {
                        return calcRegionScorePercent($scope.data, 'upperExtremities');
                    },
                    legs: function () {
                        return calcRegionScorePercent($scope.data, 'lowerExtremities');
                    },
                    totalScore: function () {
                        return regionsAreValid($scope.data) ?
                            Math.round(
                                calcRegionScore($scope.data.headNeck) * .1
                                + calcRegionScore($scope.data.trunk) * .3
                                + calcRegionScore($scope.data.upperExtremities) * .2
                                + calcRegionScore($scope.data.lowerExtremities) * .4)
                            : null;
                    }
                };
            }
        ]);