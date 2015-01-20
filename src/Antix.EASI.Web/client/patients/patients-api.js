'use strict';

angular.module('antix.easi.patients.api', [
        'ngResource'
    ])
    .factory(
        'PatientsApi',
        [
            '$resource',
            function(
                $resource) {

                return $resource('/api/patients/', {}, {
                    lookup: {
                        method: 'GET',
                        url: '/api/patients/',
                        isArray: true
                    },
                    create: {
                        method: 'POST',
                        url: '/api/patients/'
                    },
                    read: {
                        method: 'GET',
                        url: '/api/patients/:id'
                    },
                    update: {
                        method: 'PUT',
                        url: '/api/patients/:id',
                        params: { id: '@id' }
                    },
                    'delete': {
                        method: 'DELETE',
                        url: '/api/patients/:id'
                    }
                });
            }
        ]);
