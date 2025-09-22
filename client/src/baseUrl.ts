import {BookClient} from "./generated-ts-client.ts";

const isProduction = import.meta.env.prod;

const prod = "https://library-project-server.fly.dev"
const dev = "http://localhost:5197"

export const finalUrl = isProduction ? prod: dev;

export const bookClient = new BookClient(finalUrl);
