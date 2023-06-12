<script lang="ts">
import { moveCompletionSelection } from '@codemirror/autocomplete';
import SectionTitle from '../components/SectionTitle.vue';
import axios from "axios";
export default {
    components: {
        SectionTitle,
    },
    mounted() {
    },
    props: {
        entity: { type: String, required: true, default: 'entity' },
        showUpdate: { type: Boolean, default: true },
        showList: { type: Boolean, default: true },
        showCreate: { type: Boolean, default: true },
        showDelete: { type: Boolean, default: true },
    },

    data() {
        return {
            deleteId: null,
        }
    },
    methods: {
        deleteEntity() {
            if (confirm("Do you want to delete this entity?") == true) {
                axios.delete(this.entity + '/' + this.deleteId + '?isDbDelete=false')
                    .then((response) => {
                        this.$store.commit('Alert/show', { type: 'success', message: 'Entity Succesfully deleted' })
                    }).catch((error) => {
                        console.log(error)
                        this.$store.commit('Alert/show', { type: 'error', message: error.response.data.errorTranslation })
                    })
            } else {
            }
        }
    }

}
</script>
<template>
    <div class="flex flex-col bg-base-300 rounded-xl px-6 py-3 shadow my-5 flex flex-col shadow-lg">
        <div class="collapse collapse-arrow">
            <input type="checkbox" />
            <div class="collapse-title text-xl font-medium flex flex-row">
                <h1 class="underline decoration-success font-bold text-3xl">{{ entity }}</h1>
            </div>
            <div class="collapse-content">
                <!-- Create -->
                <div class="bg-base-100 rounded-xl my-3" v-if="showCreate">
                    <div class="collapse collapse-arrow ">
                        <input type="checkbox" />
                        <div class="collapse-title text-xl font-medium flex flex-row">
                            <h1 class="font-bold my-1">New {{ entity }}</h1>
                        </div>
                        <div class="collapse-content">
                            <slot name="create">

                            </slot>
                        </div>
                    </div>
                </div>
                <!-- List -->
                <div class="bg-base-100 rounded-xl my-3" v-if="showList">
                    <div class="collapse collapse-arrow ">
                        <input type="checkbox" />
                        <div class="collapse-title text-xl font-medium flex flex-row">
                            <h1 class="font-bold my-1">{{ entity }} List</h1>
                        </div>
                        <div class="collapse-content">
                            <slot name="list">

                            </slot>
                        </div>
                    </div>
                </div>
                <!-- Update -->
                <div class="bg-base-100 rounded-xl my-3" v-if="showUpdate">
                    <div class="collapse collapse-arrow ">
                        <input type="checkbox" />
                        <div class="collapse-title text-xl font-medium flex flex-row">
                            <h1 class="font-bold my-1">Update {{ entity }}</h1>
                        </div>
                        <div class="collapse-content">
                            <slot name="update">

                            </slot>
                        </div>
                    </div>
                </div>
                <!-- Delete -->
                <div class="bg-base-100 rounded-xl my-3" v-if="showDelete">
                    <div class="collapse collapse-arrow ">
                        <input type="checkbox" />
                        <div class="collapse-title text-xl font-medium flex flex-row">
                            <h1 class="font-bold my-1">Delete {{ entity }}</h1>
                        </div>
                        <div class="collapse-content">
                            <input type="number" :placeholder="entity + ' id'" v-model="deleteId"
                                class="input input-bordered w-full my-3" />
                            <button class="btn btn-error w-full" v-on:click="deleteEntity()">Delete {{ entity }}</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>