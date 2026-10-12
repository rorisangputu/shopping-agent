import { defineManifest } from "@crxjs/vite-plugin";

export default defineManifest({
  manifest_version: 3,
  name: "AI Shopping Agent",
  version: "0.1.0",
  description:
    "An AI-powered shopping assistant for planning and building shopping baskets.",
  action: {
    default_popup: "index.html",
    default_title: "AI Shopping Agent",
  },
  host_permissions: ["http://localhost/*", "http://127.0.0.1/*"],
});
