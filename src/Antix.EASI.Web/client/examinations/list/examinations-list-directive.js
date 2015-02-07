'use strict';

angular.module('antix.easi.examinations.list', [
    'antix.easi.examinations.eric',
    'antix.cellLayout'
])
    .directive(
        'examinationsList',
        [
            '$log',
            function (
                $log) {

                $log.debug('examinationsList init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examinations/list/examinations-list.cshtml',
                    scope: {
                        'items': '=examinationsList'
                    }
                };
            }
        ])

    .directive(
        'examinationsListItem',
        [
            '$log',
            function (
                $log) {


                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examinations/list/examinations-list-item.cshtml',
                    scope: {
                        'model': '=examinationsListItem'
                    }, link: function ($scope) {

                        $scope.eric = {
                            head: function () {
                                return $scope.model.headNeckScore;
                            },
                            trunk: function () {
                                return $scope.model.trunkScore;
                            },
                            arms: function () {
                                return $scope.model.upperExtremitiesScore;
                            },
                            legs: function () {
                                return $scope.model.lowerExtremitiesScore;
                            },
                            totalScore: function () {
                                return $scope.model.totalScore;
                            }
                        };

                    }
                };
            }
        ]);