'use strict';

angular.module('antix.easi.home', [
        'antix.calendar'
    ])
    .controller(
        'AntixEASIHomeController',
        [
            '$log', '$scope', '$state', '$document',
            function(
                $log, $scope, $state, $document) {

                $log.debug('AntixEASIHomeController init');

                $scope.selectedDate = new Date();
            }
        ]);