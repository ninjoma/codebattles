<script lang="ts">
import { event } from "vue-gtag"

export default {
    components: {
        
    },
  mounted() { //const loginUri = window.location.origin + import.meta.env.VITE_SSO_LOGIN_URI;
      // @ts-expect-error
      window.google.accounts.id.initialize({
        client_id: import.meta.env.VITE_GOOGLE_LOGIN_ID,
        callback: this.handleCredentialResponse,
        auto_select: true,
        itp_support: true
      })
      // @ts-expect-error
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
         this.$store.dispatch('User/loginsso', response.credential).then(() => {
            this.$store.dispatch('User/load');
         });
      },
      clicked() {
        event('login', { method: 'Google' })
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
    },
}
</script>
<template>
    <div>
        <div ref="googlebtn" />
    </div>
</template>