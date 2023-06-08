<script lang="ts">
import { mapState } from 'vuex';
import GoogleButton from './GoogleButton.vue';
import SectionTitle from './SectionTitle.vue';
import axios from "axios";
import { event } from 'vue-gtag';

export default {
    components: {
    },
    methods: {
        EnableEditing() {
            this.isEditing = true;
        },
        SaveChanges() {
            this.$store.dispatch("Profile/updateProfile", { avatarBase64: this.profile.avatarBase64, username: this.profile.username });
            this.isEditing = false;
        },
        ChangeImage(event) {
            this.selectedFile = event.target.files[0];
            this.convertToBase64();
        },
        convertToBase64() {
            if (this.selectedFile) {
                const reader = new FileReader();
                reader.onload = () => {
                    if (typeof reader.result === 'string') {
                        this.base64String = reader.result;
                        this.profile.avatarBase64 = reader.result;
                    }
                };
                reader.readAsDataURL(this.selectedFile);
            }
        }
    },
    computed: mapState({
        profile: state => state.Profile
    }),
    data() {
        return {
            isEditing: false,
            selectedFile: null,
            base64String: ''
        }
    }
}
</script>
<template>
    <div class="bg-base-100 m-5 rounded-xl p-2">
        <div class="flex flex-col sm:flex-row m-5 rounded-xl gap-3">
            <div className="avatar p-2 justify-center sm:justify-start">
                <div className="w-44 rounded-xl shadow-lg ring ring-success bg-base-100 relative">
                    <img style=' display:block;' id='base64image'
                        :src="profile.avatarBase64"
                        v-if="profile.avatarBase64 != '' && profile.avatarBase64 != null" class="w-full h-full"/>
                    <label for="file-upload" v-if="isEditing"
                        class="flex custom-file-upload w-full h-full bg-base-300/50 absolute inset-0 hover:bg-base-300/90 duration-700 items-center justify-center">
                        <font-awesome-icon icon="fa-solid fa-file-import" class="h-1/3 w-1/3" />
                    </label>
                    <input id="file-upload" v-if="isEditing" type="file" class="hidden"
                        v-bind:class="(profile.avatarBase64 != '' && profile.avatarBase64 != null) ? '' : ''"
                        v-on:change="ChangeImage($event)">

                </div>
            </div>
            <div class="flex flex-col items-stretch w-full">
                <div class="flex flex-col w-full">
                    <div class="flex w-full">
                        <div>
                            <h3 class="text-2xl font-bold text-[#36D399]"  v-if="!isEditing">{{ profile.username }}</h3>
                            <input type="text" class="input input-bordered text-2xl font-bold text-[#36D399] my-1" v-model="profile.username" v-if="isEditing">
                            <blockquote class="text-sm italic">
                                <p>ID: {{ profile.id }}</p>
                            </blockquote>
                        </div>
                        <div class="flex flex-col flex items-end flex-1 gap-1 font-inter w-full">
                            <div class="flex flex-1 items-end gap-1 font-inter">
                                <a>LEVEL</a>
                                <a class="text-3xl text-[#36D399]">{{ profile.level }}</a>
                            </div>
                            <div class="flex gap-2">
                                <div className="tooltip tooltip-bottom" data-tip="Random Text">
                                    <font-awesome-icon icon="fa-solid fa-brain" class="text-[green]" />
                                </div>
                                <div className="tooltip tooltip-bottom" data-tip="Random Text">
                                    <font-awesome-icon icon="fa-solid fa-brain" class="text-[green]" />
                                </div>
                                <div className="tooltip tooltip-bottom" data-tip="Random Text">
                                    <font-awesome-icon icon="fa-solid fa-brain" class="text-[green]" />
                                </div>
                                <div className="tooltip tooltip-bottom" data-tip="Random Text">
                                    <font-awesome-icon icon="fa-solid fa-brain" class="text-[green]" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="py-2 flex flex-col items-center rounded-xl w-full">
                        <progress className="progress progress-success h-10 m-1 rounded-sm" :value="profile.experience"
                            :max="Math.max(1, profile.level) * 1000"></progress>
                        <div class="flex justify-end font-inter w-full">
                            <a>{{ profile.experience }} / {{ Math.max(1, profile.level) * 1000 }} EXP</a>
                        </div>
                    </div>
                    <div class="flex gap-2 w-full">
                        <button className="btn flex gap-2 flex-1">
                            <font-awesome-icon icon="fa-solid fa-plus" /> Friend List
                        </button>
                        <button className="btn flex gap-2 flex-1">
                            <font-awesome-icon icon="fa-solid fa-flag" /> Report
                        </button>
                        <button v-if="$store.state.User.id == $store.state.Profile.id && !isEditing"
                            className="btn flex gap-2 flex-1" v-on:click="EnableEditing()">
                            <font-awesome-icon icon="fa-solid fa-pen-to-square" /> Edit Profile
                        </button>
                        <button v-if="$store.state.User.id == $store.state.Profile.id && isEditing"
                            className="btn btn-success flex gap-2 flex-1" v-on:click="SaveChanges()">
                            <font-awesome-icon icon="fa-solid fa-pen-to-square" /> Save Changes
                        </button>
                    </div>
                    <div class="flex">

                    </div>
                </div>
                <div class="flex gap-1">
                    <div class="">
                        <div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>