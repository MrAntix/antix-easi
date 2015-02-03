'use strict';

angular.module('antix.easi.examinations.severityScore', [
])
    .directive(
        'examinationSeverityScore',
        [
            '$log',
            function (
                $log,
                ExaminersApi) {

                $log.debug('examinationSeverityScore init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examinations/region-score/examination-severity-score.cshtml',
                    scope: {
                        'model': '=ngModel'
                    },
                    link: function ($scope, element, attrs) {
                        $log.debug('examinationSeverityScore link');

                    }
                };
            }
        ]);