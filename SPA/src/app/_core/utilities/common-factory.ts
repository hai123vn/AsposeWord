const port: number = 1905; // LOCAL

const protocol: string = window.location.protocol;
const hostname: string = window.location.hostname;
const ip: string = `${hostname}:${port}`;
const apiUrl: string = `${protocol}//${ip}`;




export const CommonFactory = {
    baseUrl: `${apiUrl}/`,
    apiUrl: `${apiUrl}/api/`,
    // userCounterUrl: `${apiUrl}/UserCounter`, // Đếm người onl
    allowedDomains: [ip],
    disallowedRoutes: [`${apiUrl}/authentication`],
}
