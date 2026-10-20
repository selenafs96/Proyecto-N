import LoginFeatureSlider from "@/src/components/LoginFeatureSlider";
import LoginForm from "@/src/components/LoginForm";

function LoginPage( { onClose } : { readonly onClose: () => void } ) {
  return (
    <main className="flex w-full justify-center items-center">
      { /* Left container */ }
       <LoginFeatureSlider />
      { /* Right container */ }
      <LoginForm onClose={onClose}/>
    </main>
  );
}

export default LoginPage;