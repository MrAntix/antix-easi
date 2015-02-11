'use strict';

angular.module('antix.easi.home', [
        'antix.calendar'
    ])
    .controller(
        'AntixEASIHomeController',
        [
            '$log', '$scope', '$state',
            function(
                $log, $scope, $state) {

                $log.debug('AntixEASIHomeController init');

            }
        ]);