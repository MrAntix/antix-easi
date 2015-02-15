'use strict';

angular.module('antix.easi.patients.list', [
    'antix.cellLayout'
])
    .directive(
        'patientsList',
        [
            '$log',
            function (
                $log) {

                $log.debug('patientsList init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'patients/list/patients-list.cshtml',
                    scope: {
                        'models': '=patientsList'
                    }
                };
            }
        ])

    .directive(
        'patientsListItem',
        [
            '$log',
            function (
                $log) {


                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'patients/list/patients-list-item.cshtml',
                    scope: {
                        'model': '=patientsListItem'
                    }
                };
            }
        ]);