'use strict';

angular.module('antix.easi.clinicians.api', [
        'ngResource'
    ])
    .factory(
        'CliniciansApi',
        [
            '$resource',
            function(
                $resource) {

                return $resource('/api/clinicians/', {}, {
                    lookup: {
                        method: 'GET',
                        url: '/api/clinicians/lookup',
                        isArray: true
                    },
                    create: {
                        method: 'POST',
                        url: '/api/clinicians'
                    }
                });
            }
        ]);
