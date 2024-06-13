const BASE_URL = process.env.REACT_APP_BASE_URL || "";

const REGISTER_URL = `${BASE_URL}/Auth/Register`;
const LOGIN_URL = `${BASE_URL}/Auth/Login`;
const CHANGE_PASSWORD_URL = `${BASE_URL}/Auth/change-password`;
const REFRESH_URL = `${BASE_URL}/Jwt`;

export {LOGIN_URL, REFRESH_URL, CHANGE_PASSWORD_URL, REGISTER_URL};