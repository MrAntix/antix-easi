'use strict';

angular.module('antix.easi.home', [
        
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