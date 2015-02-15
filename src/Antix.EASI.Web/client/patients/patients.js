'use strict';

angular.module('antix.easi.patients', [
        'antix.easi.patients.api',
        'antix.easi.patients.index',
        'antix.easi.patients.select',
        'antix.easi.patients.create',
        'antix.easi.patients.edit',
        'antix.easi.patients.info'
    ])
    .config([
        '$stateProvider',
        function(
            $stateProvider
        ) {
            $stateProvider
                .state('patients-index', {
                    url: '/patients/',
                    templateUrl: '/client/patients/index/patients-index.cshtml',
                    controller: 'AntixEASIPatientsIndexController'
                })
                .state('patients-create', {
                    url: '/patients/create',
                    templateUrl: '/client/patients/create/patients-create.cshtml',
                    controller: 'AntixEASIPatientsCreateController'
                })
                .state('patients-edit', {
                    url: '/patients/{id}/edit',
                    templateUrl: '/client/patients/edit/patients-edit.cshtml',
                    controller: 'AntixEASIPatientsEditController'
                });

        }
    ])
    .constant('PatientEvents', {
        Created: 'patient-event:created',
        Updated: 'patient-event:updated',
        Deleted: 'patient-event:deleted'
    })
    .filter('patientName', [
        function () {
            return function (patient) {
                return patient.name + ' (' + patient.identifier + ')';
            };
        }
    ]);