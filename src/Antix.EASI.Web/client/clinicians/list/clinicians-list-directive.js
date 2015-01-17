'use strict';

angular.module('antix.easi.clinicians.list', [
    'antix.cellLayout'
])
    .directive(
        'cliniciansList',
        [
            '$log',
            function (
                $log) {

                $log.debug('cliniciansList init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'clinicians/list/clinicians-list.cshtml',
                    scope: {
                        'items': '=cliniciansList'
                    }
                };
            }
        ])

    .directive(
        'cliniciansListItem',
        [
            '$log',
            function (
                $log) {


                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'clinicians/list/clinicians-list-item.cshtml',
                    scope: {
                        'item': '=cliniciansListItem'
                    }
                };
            }
        ]);