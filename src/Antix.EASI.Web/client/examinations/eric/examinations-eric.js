'use strict';

angular.module('antix.easi.examinations.eric', [
])
    .directive(
        'examinationEric',
        [
            '$log',
            function (
                $log) {

                $log.debug('examinationEric init');

                return {
                    restrict: 'EA',
                    replace: false,
                    templateUrl: 'examinations/eric/examinations-eric.svg',
                    scope: {
                        'model': '=ngModel'
                    },
                    link: function ($scope, element, attrs) {
                        $log.debug('examinationEric link');

                    }
                };
            }
        ]);