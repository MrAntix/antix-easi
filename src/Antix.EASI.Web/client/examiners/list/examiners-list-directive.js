'use strict';

angular.module('antix.easi.examiners.list', [
    'antix.cellLayout'
])
    .directive(
        'examinersList',
        [
            '$log',
            function (
                $log) {

                $log.debug('examinersList init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examiners/list/examiners-list.cshtml',
                    scope: {
                        'items': '=examinersList'
                    }
                };
            }
        ])

    .directive(
        'examinersListItem',
        [
            '$log',
            function (
                $log) {


                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examiners/list/examiners-list-item.cshtml',
                    scope: {
                        'item': '=examinersListItem'
                    }
                };
            }
        ]);