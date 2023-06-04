<script lang="ts">
export default {
    components: {
        
    },
    mounted() { //const loginUri = window.location.origin + import.meta.env.VITE_SSO_LOGIN_URI;
      window.google.accounts.id.initialize({
        client_id: import.meta.env.VITE_GOOGLE_LOGIN_ID,
        callback: this.handleCredentialResponse,
        auto_select: true
      })
      window.google.accounts.id.renderButton(
        this.$refs.googlebtn, {
          text: 'signin',
          size: 'large',
          width: '366',
          theme: 'outline',
          logo_alignment: 'left'
        }
      )
    },
    methods: {
      async handleCredentialResponse(response) {
         this.$store.dispatch('User/loginsso', response.data);
      }
    },
    watch: {
        "$store.state.User.isLogged": {
            handler(isLogged) {
                if(isLogged == true) {
                    this.$router.push("/battle");
                } 
            }
        }
    }
}
</script>
<template>
    <div>
        <div ref="googlebtn" />
    </div>
</template>