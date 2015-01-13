'use strict';

angular.module('antix.easi.clinicians', [
        'antix.easi.clinicians.api',
        'antix.easi.clinicians.select',
        'antix.easi.clinicians.create'
    ])
    .config([
        '$stateProvider',
        function(
            $stateProvider
        ) {
            $stateProvider
                .state('clinicians-create', {
                    url: '/clinicians/create',
                    templateUrl: '/client/clinicians/create/clinicians-create.cshtml',
                    controller: 'AntixEASICliniciansCreateController'
                });
        }
    ])
    .constant('ClinicianEvents', {
        Created: 'clinician-event:created'
    });