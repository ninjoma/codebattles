<script lang="ts">
import SectionTitle from '../components/SectionTitle.vue';
import AdminEntityContainer from '../components/AdminEntityContainer.vue'
import BadgeForm from '../components/Forms/BadgeForm.vue'
import GameModeForm from '../components/Forms/GameModeForm.vue'
import LanguageForm from '../components/Forms/LanguageForm.vue'
import EntityListContainer from '../components/Lists/EntityListContainer.vue'
import BadgeList from '../components/Lists/BadgeListComponent.vue'
import LanguageList from '../components/Lists/LanguageListComponent.vue'
export default {
    components: {
        SectionTitle,
        AdminEntityContainer,
        BadgeForm,
        LanguageForm,
        EntityListContainer,
        BadgeList,
        LanguageList,
        GameModeForm,
    },
    mounted() {
    },
    data() {
        return {
            test: [
                { icon: 'devicon-nodejs-plain', name: 'Javascript', isActive: false, id: 1,  disabled: false },
                { icon: 'devicon-csharp-plain', name: 'C Sharp', isActive: false, id: 2, disabled: true },
                { icon: 'devicon-python-plain', name: 'Python', isActive: false, id: 3, disabled: true },
                { icon: 'devicon-rust-plain', name: 'Rust', isActive: false, id: 4, disabled: true },
                { icon: 'devicon-cplusplus-plain', name: 'C++', isActive: false, id: 5, disabled: true },
                { icon: 'devicon-css3-plain', name: 'CSS', isActive: false, id:6, disabled: true },
            ]
        }
    },
}
</script>
<template>
    <div class="flex flex-col flex-1 items-center">
        <div class="max-w-screen-2xl w-full p-2 ">
            <AdminEntityContainer entity="Badge" :showUpdate="false" :showDelete="true">
                <template #create>
                    <BadgeForm/>
                </template>
                <template #list>
                    <BadgeList/>
                </template>
            </AdminEntityContainer>
            <AdminEntityContainer entity="Game" :showUpdate="false" :showDelete="true" :showCreate="false" :showList="false">
                <template #create>
                    <BadgeForm/>
                </template>
                <template #list>
                    <BadgeList/>
                </template>
            </AdminEntityContainer>
            <AdminEntityContainer entity="Friend" :showUpdate="false" :showDelete="true" :showCreate="false" :showList="false">
                <template #create>
                    <BadgeForm/>
                </template>
                <template #list>
                    <BadgeList/>
                </template>
            </AdminEntityContainer>
            <AdminEntityContainer entity="GameMode" :showUpdate="false" :showDelete="true" :showCreate="true" :showList="false">
                <template #create>
                    <GameModeForm/>
                </template>
                <template #list>
                    <BadgeList/>
                </template>
            </AdminEntityContainer>
            <AdminEntityContainer entity="Language" :showUpdate="false" :showDelete="true">
                <template #create>
                    <LanguageForm/>
                </template>
                <template #list>
                    <LanguageList/>
                </template>
            </AdminEntityContainer>
        </div>
    </div>
</template>