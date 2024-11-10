import SuccessfullyLog from "../../../helpers/SuccessfullyLog.jsx";
import UnSuccessfullyLog from "../../../helpers/UnSuccessfullyLog.jsx";


export default async (searchParams = null, options = null) =>  {

    const url = new URL('https://localhost:80/api/ApiColor/');

    if (searchParams) {
        searchParams.map (p => {
            url.searchParams.append(p.name, p.value)
        })
    }

    toast.info(url.toString())


    try {
        const response = await fetch(url, {
            headers: {
            },
            ...options,
        });

        SuccessfullyLog(response.statusText)

        return await response.json();
    } catch (error) {
        UnSuccessfullyLog(error)
    }
}