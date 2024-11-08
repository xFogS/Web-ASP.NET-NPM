import SuccessfullyLog from "./SuccessfullyLog";
import UnSuccessfullyLog from "./UnSuccessfullyLog";


export const MyFetch = async (url, options = {}) => {

    url = 'http://localhost:80/api/' + url;

    try {
        const response = await fetch(url, {
            headers: {
                'Accept-Language': 'uk-UA, ru-RU;q=0.9',
            },
            ...options,
        });
        SuccessfullyLog(response.statusText)

        return await response.json();
    } catch (error) {
        UnSuccessfullyLog(error)
    }
};