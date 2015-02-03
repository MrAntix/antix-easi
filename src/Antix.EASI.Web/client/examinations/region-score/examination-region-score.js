'use strict';

angular.module('antix.easi.examinations.regionScore', [
    'antix.easi.examinations.severityScore'
])
    .directive(
        'examinationRegionScore',
        [
            '$log',
            function (
                $log,
                ExaminersApi) {

                $log.debug('examinationRegionScore init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examinations/region-score/examination-region-score.cshtml',
                    scope: {
                        'model': '=ngModel'
                    },
                    link: function ($scope, element, attrs) {
                        $log.debug('examinationRegionScore link');

                    }
                };
            }
        ]);