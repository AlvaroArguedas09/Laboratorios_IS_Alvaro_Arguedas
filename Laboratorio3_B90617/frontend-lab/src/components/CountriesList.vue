<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de países</h1>
        <table class="table is-bordered is-striped is-narrow is-hoverable
          is-fullwidth">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(country, index) of countries" :key="index">
                    <td>{{ country.name}}</td>
                    <td>{{ country.continent}}</td>
                    <td>{{ country.language}}</td>
                    <td>
                        <button class="btn btn-secondary btn-sm">Editar</button>
                        <button class="btn btn-danger btn-sm" @click="deleteCountry(index)">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios";
    export default {
        name: "CountriesList",
        data() {
            return {
                countries: [],
            };
        },
        methods: {

            deleteCountry(index) {

                this.countries.splice(index, 1);

            },
            getCountries() {

                axios.get("https://localhost:7214/api/Country").then((response) => {
                        this.countries = response.data;
                    });
            },
        },
        created: function () {
            this.getCountries();
        },
    };
</script>

<style lang="scss" scope> </style>