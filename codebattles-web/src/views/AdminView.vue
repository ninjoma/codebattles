<script lang="ts">
import SectionTitle from '../components/SectionTitle.vue';
import AdminEntityContainer from '../components/AdminEntityContainer.vue'
import BadgeForm from '../components/BadgeForm.vue'
import EntityListContainer from '../components/EntityListContainer.vue'
import BadgeList from '../components/BadgeListComponent.vue'
export default {
    components: {
        SectionTitle,
        AdminEntityContainer,
        BadgeForm,
        EntityListContainer,
        BadgeList,
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
        </div>
    </div>
</template>