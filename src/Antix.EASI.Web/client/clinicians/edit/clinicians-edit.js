'use strict';

angular.module('antix.easi.clinicians.edit', [
        'antix.easi.clinicians.api'
])
    .controller(
        'AntixEASICliniciansEditController',
        [
            '$log', '$scope', '$state',
            'CliniciansApi', 'ClinicianEvents',
            function (
                $log, $scope, $state,
                CliniciansApi, ClinicianEvents) {

                $log.debug('AntixEASICliniciansEditController init');

            }
        ]);