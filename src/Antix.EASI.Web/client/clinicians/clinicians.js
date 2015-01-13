'use strict';

angular.module('antix.easi.clinicians', [
        'antix.easi.clinicians.api',
        'antix.easi.clinicians.select',
        'antix.easi.clinicians.create',
        'antix.easi.clinicians.edit'
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
                })
                .state('clinicians-edit', {
                    url: '/clinicians/{id}/edit',
                    templateUrl: '/client/clinicians/edit/clinicians-edit.cshtml',
                    controller: 'AntixEASICliniciansEditController'
                });

        }
    ])
    .constant('ClinicianEvents', {
        Created: 'clinician-event:created',
        Updated: 'clinician-event:updated',
        Deleted: 'clinician-event:deleted'
});