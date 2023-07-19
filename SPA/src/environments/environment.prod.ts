const port = 9005;
const ip = `${window.location.hostname}:${port}`;
const apiUrl = `https://${ip}`;


export const environment = {
  production: true,
  apiUrl: `${apiUrl}/api/`,
  baseUrl: `${apiUrl}/`,
};
