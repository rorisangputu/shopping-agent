# ShopAI — AI Shopping Agent

An AI-powered shopping assistant designed to turn natural-language shopping requests into structured requirements, relevant product recommendations and proposed shopping baskets.

## Overview

ShopAI is a Chrome extension that aims to simplify online shopping by allowing users to describe what they need in everyday language rather than searching for every product individually.

Users will be able to describe a shopping task, including the occasion, number of people, budget, quantities and preferences. The system will interpret the request, identify suitable products, assemble a proposed basket and allow the user to review the selections before proceeding.

The initial product catalogue will use mock data while the shopping workflow is developed. Integration with a real product data source, such as Makro, will follow once an appropriate access method has been established.

## Problem Statement

Traditional online shopping requires users to search for products individually, compare options, calculate quantities and keep track of their budgets.

ShopAI aims to reduce this effort by interpreting a user's overall shopping goal and helping translate it into a practical, budget-aware shopping basket.

## Project Objectives

- Accept natural-language shopping requests.
- Convert requests into structured shopping requirements.
- Search and match products against a catalogue.
- Recommend products based on relevant constraints.
- Assemble a proposed shopping basket.
- Present selections and costs clearly for user review.
- Introduce voice input and more advanced agent capabilities in later iterations.

## Planned Features

### Minimum Viable Product

- Chrome extension with a shopping assistant interface.
- Text-based shopping requests.
- Structured requirement extraction using an LLM.
- Product catalogue search and matching.
- Basket creation and quantity management.
- Budget calculations.
- User confirmation before consequential shopping actions.

### Future Enhancements

- Voice input and speech-to-text.
- Integration with an approved real-world product data source.
- Product availability and substitution handling.
- Saved preferences and shopping sessions.
- Improved budget and package-size optimisation.
- Cloud deployment and production monitoring.

## Technology Stack

| Component         | Technology                                           |
| ----------------- | ---------------------------------------------------- |
| Browser interface | Chrome Extension, Manifest V3                        |
| Frontend          | React, TypeScript, Vite                              |
| Backend           | C#, ASP.NET Core Web API                             |
| Product data      | Mock catalogue initially; SQL planned                |
| AI                | LLM with structured outputs and tool calling planned |
| Cloud             | Microsoft Azure planned                              |
| Containers        | Docker planned                                       |

## Architecture

The Chrome extension will provide the user interface and communicate with an ASP.NET Core API over HTTP.

The backend will eventually coordinate AI-assisted requirement extraction, product searches, basket calculations and other shopping operations.

A product provider abstraction is planned to separate the shopping workflow from the underlying product data source.

## Current Development Status

**Completed**

- Initial React and TypeScript frontend.
- Vite development and build configuration.
- Chrome Extension Manifest V3 configuration.
- Basic ShopAI popup interface.
- ASP.NET Core Web API project.
- Health endpoint at `GET /api/health`.
- Local frontend-to-backend connectivity check.

**In Progress**

- Product catalogue model and sample data.
- Product retrieval and search endpoints.

**Planned**

- AI requirement extraction.
- Product matching and basket generation.
- Budget-aware recommendations.
- Voice input.
- Real product data integration.
- Docker and Azure deployment.

## Development Setup

### Prerequisites

- Node.js and npm.
- A compatible .NET SDK.
- Google Chrome.
- Git.

### Frontend

Navigate to the extension project:

```bash
cd client/extension
npm install
npm run dev
```

To build the extension:

```bash
npm run build
```

Load the generated `dist/` directory through `chrome://extensions` with Developer mode enabled.

### Backend

Navigate to the API project:

```bash
cd server/AiShoppingAgent.Api
dotnet run
```

Use the local URL printed by ASP.NET Core to access the running API.

The health endpoint is available at:

```text
/api/health
```

The frontend's configured API URL must match the backend's local HTTP address and port.

## Project Principles

- Build a working MVP before introducing advanced features.
- Keep the AI's outputs structured and validate them on the backend.
- Separate product-source integration from shopping logic.
- Make costs, product selections and substitutions transparent.
- Require user approval before consequential purchasing actions.
- Keep secrets out of source control.
- Document architectural decisions and test important business logic.

## Project Status

ShopAI is under active development. The current implementation is a local prototype; AI functionality, live product integration and production deployment have not yet been completed.
