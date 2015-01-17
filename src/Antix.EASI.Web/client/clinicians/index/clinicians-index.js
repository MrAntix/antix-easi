'use strict';

angular.module('antix.easi.clinicians.index', [
        'antix.easi.clinicians.list',
        'antix.easi.clinicians.api'
    ])
    .controller(
        'AntixEASICliniciansIndexController',
        [
            '$log', '$scope',
            'CliniciansApi',
            function(
                $log, $scope,
                CliniciansApi) {

                $log.debug('AntixEASICliniciansIndexController init');

                CliniciansApi.lookup({
                        text: ''
                    }).$promise
                    .then(function(data) {
                        $scope.clinicians = data;
                    });
            }
        ]);