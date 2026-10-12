import { useEffect, useState } from "react";
import "./App.css";

const API_BASE_URL = "http://localhost:5138";

type ConnectionStatus = "checking" | "connected" | "disconnected";

function App() {
  const [request, setRequest] = useState("");
  const [connection, setConnection] = useState<ConnectionStatus>("checking");

  useEffect(() => {
    const controller = new AbortController();

    async function checkBackend() {
      try {
        const response = await fetch(`${API_BASE_URL}/api/health`, {
          signal: controller.signal,
        });

        if (!response.ok) {
          throw new Error("Backend returned an error");
        }

        const data: { status: string; service: string } = await response.json();

        setConnection(data.status === "ok" ? "connected" : "disconnected");
      } catch {
        if (!controller.signal.aborted) {
          setConnection("disconnected");
        }
      }
    }

    checkBackend();

    return () => controller.abort();
  }, []);

  function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if (!request.trim()) return;

    alert(`Shopping request: ${request}`);
  }

  const connectionLabel = {
    checking: "Checking backend...",
    connected: "Backend: Connected",
    disconnected: "Backend: Disconnected",
  }[connection];

  return (
    <main className="app">
      <header className="header">
        <div className="logo">S</div>
        <div>
          <h1>ShopAI</h1>
          <p>Your personal shopping assistant</p>
        </div>
      </header>

      <div className={`connection ${connection}`}>
        <span className="connection-dot" />
        {connectionLabel}
      </div>

      <section className="intro">
        <span className="eyebrow">SMARTER SHOPPING</span>
        <h2>What are we shopping for?</h2>
        <p>Tell me what you need, who it's for, and your budget.</p>
      </section>

      <form onSubmit={handleSubmit}>
        <label htmlFor="request">Your shopping request</label>
        <textarea
          id="request"
          value={request}
          onChange={(event) => setRequest(event.target.value)}
          placeholder="I'm hosting a braai for 10 people..."
          rows={5}
        />

        <button type="submit" disabled={!request.trim()}>
          Start planning <span aria-hidden="true">→</span>
        </button>
      </form>

      <footer>AI-powered shopping · You stay in control</footer>
    </main>
  );
}

export default App;
