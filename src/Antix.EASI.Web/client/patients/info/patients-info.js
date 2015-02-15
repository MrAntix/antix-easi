'use strict';

angular.module('antix.easi.patients.info', [
    ])
    .directive(
        'patientInfo',
        [
            '$log',
            function(
                $log) {

                $log.debug('patientInfo init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'patients/info/patients-info.html',
                    scope: {
                        'model': '=patientInfo'
                    }
                };
            }
        ]);