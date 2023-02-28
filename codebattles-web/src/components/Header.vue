<script lang="ts">
import HeaderButton from "./HeaderButton.vue";
export default {
    components: {
        HeaderButton
    }

}
</script>
<template>
    <div className="navbar bg-base-300 flex items-center justify-between gap-3 p-0 px-2 items-stretch drop-shadow-lg">
        <div>
            <a className="normal-case text-xl font-inter font-bold px-2">>/&lt; CODE BATTLES</a>
            <div class="h-full flex gap-3">
                <HeaderButton targetUrl="/lobby">
                    <a>Lobby</a>
                </HeaderButton>
                <HeaderButton targetUrl="/battle">
                    <a>Battles</a>
                </HeaderButton>
                <HeaderButton targetUrl="/coop">
                    <a>Co-Op</a>
                </HeaderButton>
            </div>
        </div>
        <div>
            <div class="h-full flex gap-3">
                <HeaderButton targetUrl="/profile">
                    <font-awesome-icon icon="fa-solid fa-user" />
                </HeaderButton>
                <HeaderButton targetUrl="/logout">
                    <font-awesome-icon icon="fa-solid fa-right-from-bracket" />
                </HeaderButton>
            </div>
        </div>
    </div>
</template>