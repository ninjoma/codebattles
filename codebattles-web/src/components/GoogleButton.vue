<script lang="ts">
export default {
    components: {
        
    },
    data() {
        const googleClientID = import.meta.env.VITE_GOOGLE_LOGIN_ID;
        const loginUri = window.location.origin + import.meta.env.VITE_SSO_LOGIN_URI;
        return {
            googleClientID,
            loginUri
        }
    }
}
</script>
<template>
    <div>
        <div id="g_id_onload"
            :data-client_id=googleClientID
            :data-login_uri=loginUri
            data-auto_prompt="false">
        </div>
        <div class="g_id_signin"
            data-type="standard"
            data-size="large"
            data-theme="outline"
            data-text="sign_in_with"
            data-shape="rectangular"
            data-logo_alignment="left">
        </div>
    </div>
</template>