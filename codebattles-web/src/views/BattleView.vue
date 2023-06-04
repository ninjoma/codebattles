<script lang="ts">
import SectionTitle from '../components/SectionTitle.vue';
import BattleContainer from '../components/BattleContainer.vue';
import BattleCreationComponent from '../components/BattleCreationComponent.vue';
export default {
    components: { SectionTitle, BattleContainer, BattleCreationComponent }
}
</script>
<template>
<div class="flex flex-col flex-1 items-center">
    <div class="max-w-screen-lg w-full p-2">
        <div class="bg-base-300 rounded-xl px-6 py-3 shadow my-5 flex flex-col">
            <BattleCreationComponent/>
        </div>
        <div class="flex flex-col gap-3">
            <BattleContainer/>
            <BattleContainer/>
            <BattleContainer/>
            <BattleContainer/>
        </div>
    </div>
    <!-- Create Modal -->
    <input type="checkbox" id="create-modal" className="modal-toggle" />
    <div className="modal">
        <div className="modal-box px-8 py-5">
            <div className="flex items-center justify-between">
                <SectionTitle>Create Battle</SectionTitle>
                <label htmlFor="create-modal" className=""> 
                    <font-awesome-icon icon="fa-solid fa-xmark" />
                </label>
            </div>
            <div>
                <div className="form-control w-full">
                    <label className="label">
                        <span className="label-text">Lobby Name</span>
                    </label>
                    <input type="text" placeholder="Type here" className="input input-bordered w-full" />
                </div>
            </div>
            <div className="modal-action">
                <button className="btn">Create</button>
                
            </div>
        </div>
    </div>
</div>
</template>