const isProduction = import.meta.env.prod;

const prod = "https://library-project-server.fly.dev"
const dev = "http://localhost:5173/"

export const finalUrl = isProduction ? prod: dev;
