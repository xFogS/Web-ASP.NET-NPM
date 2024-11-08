import { MyFetch } from "../../helpers/MyFetch";
import SuccessfullyLog from "../../helpers/SuccessfullyLog";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default (props) => {

    const notify = toast.success("Operation is success!")
    const onSubmit = (ev) => {
        ev.preventDefault()

        const frmData = new FormData(ev.target)

        MyLog(frmData)

        MyFetch('ApiColor', {
            method: "POST",
            body: frmData
        })
            .then(res => {
                MyLog(res)
                props.getColors()
                notify();
            })
        return false;
    }
    < ToastContainer />
    return (
        <form onSubmit={onSubmit} method='POST' enctype="multipart/form-data">
            <input type='text' name='Name' />
            <input type='file' name='URL' accept="image/png, image/jpeg"/>
            <input type='color' name='RGB' />
            <input type='text' name='Code' />
            <input type='submit' />
        </form>
    )

}