import { useEffect, useRef } from "react";
import LoginFeatureSlider from "./LoginFeatureSlider";
import LoginForm from "./LoginForm";

type LoginDialogProps = {
    open: boolean,
    onClose: () => void
}

function LoginDialog({ open, onClose }: LoginDialogProps) {

    const dialogRef = useRef<HTMLDialogElement>(null);
    

    useEffect(() => {
        const dialog = dialogRef.current;

        if(!dialog) return;

        if(dialog && !dialog.open) {
            dialog.showModal();
        }

        if(!open && dialog.open) {
            dialog.close();
        }

    }, [open])


    { /* When the user closes de dialog using Esc, this changes the react state "open" */ }
    useEffect(() => {
        const dialog = dialogRef.current;
        if (!dialog) return;

        const handleClose = () => {
            onClose();
        };

        dialog.addEventListener("close", handleClose);
        return () => dialog.removeEventListener("close", handleClose);
    }, [onClose]);

  return (
    <dialog
        ref={dialogRef}
        className="m-0 h-dvh max-h-none w-full max-w-none overflow-y-auto bg-transparent p-4 sm:p-6"
        aria-label="login"
    >
      <div className="flex w-full min-h-full justify-center items-center">
        {/* Left container */}
        <LoginFeatureSlider />
        {/* Right container */}
        <LoginForm onClose={onClose} />
      </div>
    </dialog>
  );
}

export default LoginDialog;
