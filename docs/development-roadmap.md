# ShopAI --- Development Roadmap

**Document status:** Initial version\
**Project status:** Early prototype\
**Last updated:** 12 October 2026

## 1. Purpose

This roadmap defines the planned implementation sequence for ShopAI,
from the current local prototype to a usable minimum viable product
(MVP). It prioritises working end-to-end functionality, keeps scope
controlled, and identifies the conditions for considering each milestone
complete.

Dates and durations are intentionally not committed yet. Work should be
estimated after the relevant requirements and technical uncertainties
are understood.

## 2. Product Goal

Build a Chrome extension that lets a user describe a shopping task in
natural language, converts the request into structured requirements,
searches an available product catalogue, and presents a proposed basket
for the user to review.

The initial MVP will use mock product data. Integration with a real
retailer catalogue, voice input, cloud deployment, and other
enhancements will follow only after the core text-based shopping flow
works.

## 3. Delivery Principles

- Build a small working increment at each milestone.
- Keep implemented functionality distinct from planned functionality.
- Validate API contracts and business rules before adding more layers.
- Use mock product data until the catalogue search workflow is proven.
- Keep model-generated data untrusted until validated by the backend.
- Require user review before consequential purchasing actions.
- Add infrastructure when the product needs it, not merely to include
  a technology.
- Update the README, architecture document, and this roadmap when
  material changes occur.

## 4. Current Status

### Milestone 1 --- Foundation

**Status:** Core functionality implemented; Git checkpoint to be
confirmed.

Completed: - React + TypeScript frontend created with Vite. - Chrome
Extension Manifest V3 configuration added. - Basic ShopAI popup
implemented. - ASP.NET Core Web API project created. - `GET /api/health`
endpoint implemented. - Extension configured to call the local API. -
CORS and localhost host permissions configured for local development. -
Connection indicator verified as connected.

Not yet confirmed: - A clean Git commit and push of the working
foundation. - Swagger/OpenAPI setup.

## 5. Milestones and Acceptance Criteria

### Milestone 1 --- Foundation and Local Integration

**Goal:** Establish a working frontend-to-backend development setup.

Tasks: - \[x\] Create React + TypeScript extension project. - \[x\]
Configure Manifest V3 and build output. - \[x\] Create ASP.NET Core
API. - \[x\] Add health endpoint. - \[x\] Connect extension to the
health endpoint. - \[ \] Review `.gitignore` and ensure no secrets or
generated output are accidentally committed. - \[ \] Commit and push a
known-good foundation. - \[ \] Add Swagger/OpenAPI later when the API
surface begins to grow.

**Acceptance criteria** - `npm run build` completes successfully. - The
extension can be loaded from the generated `dist/` directory. - The API
starts locally and `GET /api/health` returns a successful JSON
response. - The extension displays a connected state when the health
request succeeds and a disconnected state when it fails.

### Milestone 2 --- Product Catalogue and Search

**Goal:** Make a product catalogue available through the API without
introducing external data-source dependencies.

Tasks: - Define a `Product` model with a stable ID, name, category,
price, package size, and availability indicator. - Define
request/response models for product search where appropriate. - Create
mock product data covering representative shopping categories. -
Implement `GET /api/products`. - Implement
`GET /api/products/search?q=...`. - Add basic input validation and
consistent error handling. - Test search behaviour, empty queries, no
matches, and invalid values. - Document endpoint behaviour and sample
responses.

**Acceptance criteria** - The product endpoint returns valid JSON with a
predictable schema. - Search can find products by relevant name or
category terms. - Empty and unmatched searches behave predictably. -
Prices and package sizes are represented consistently. - The catalogue
is isolated so the mock source can later be replaced without rewriting
the shopping workflow.

**Scope note:** Start with an in-memory catalogue. Add a database only
when persistence or other requirements justify it.

### Milestone 3 --- Shopping Request Contract

**Goal:** Define how the extension submits a shopping request and how
the API represents it.

Tasks: - Design the shopping request and response contracts. - Identify
fields such as the shopping occasion, number of people, budget,
requested categories, quantities, exclusions, and preferences. - Define
validation rules for optional and required fields. - Decide how the API
represents missing information and clarification needs. - Replace the
temporary alert-only submit action with a call to the API. - Display
loading, success, and error states in the popup.

**Acceptance criteria** - The extension can submit a request to the
API. - The API validates the request and returns a documented
response. - Invalid input is rejected with a useful error. - The UI
handles loading and failure states without losing the user's request.

### Milestone 4 --- AI Requirement Extraction

**Goal:** Convert natural-language shopping requests into structured,
validated requirements.

Tasks: - Select an LLM provider and configure credentials securely on
the backend. - Define a schema for structured shopping requirements. -
Implement requirement extraction through the backend. - Validate model
output and handle malformed or incomplete responses. - Add targeted
clarification when essential information is missing. - Create
representative test cases for clear, ambiguous, conflicting, and
budget-constrained requests.

**Acceptance criteria** - Example text requests produce schema-valid
structured requirements. - Missing or ambiguous critical details are
surfaced rather than silently invented. - API keys are not exposed in
extension code or source control. - Failures and timeouts return
controlled errors.

### Milestone 5 --- Product Matching and Proposed Basket

**Goal:** Turn validated requirements into a useful proposed basket.

Tasks: - Connect structured requirements to product search. - Match
products using category, quantity, package size, exclusions, and
preferences where supported. - Implement deterministic backend
calculations for quantities and totals. - Track the budget and remaining
balance. - Handle missing products, unavailable items, and baskets over
budget. - Return product choices with explanations and known
limitations. - Display the proposed basket in the extension. - Allow
users to review and adjust proposed quantities.

**Acceptance criteria** - A text request can produce a proposed basket
using the mock catalogue. - Basket totals are calculated on the backend
using decimal-safe monetary arithmetic. - Product identifiers and
quantities are validated. - The user can see the selected products,
quantities, prices, and total. - Unsatisfied requirements and budget
conflicts are communicated clearly. - No purchase or checkout action
occurs automatically.

### Milestone 6 --- End-to-End Text MVP

**Goal:** Complete and test the core shopping journey.

Intended flow:

1.  User submits a shopping request.
2.  API extracts structured requirements.
3.  The system searches the product catalogue.
4.  The backend builds and calculates a proposed basket.
5.  The system asks for clarification when necessary.
6.  The extension displays the proposal.
7.  The user reviews and confirms the proposed basket.

Tasks: - Test the happy path and important edge cases. - Add unit tests
for validation, matching rules, and basket calculations. - Add API
integration tests for the main endpoints. - Improve UI feedback and
accessibility. - Update the README and architecture documentation. -
Record known limitations and create a demo.

**Acceptance criteria** - The full text-based flow works locally from
request to proposed basket. - Critical business rules have automated
tests. - Errors do not produce misleading success states. - The user
remains in control of the proposed basket. - Setup instructions allow
the project to be run from a clean checkout.

### Milestone 7 --- Voice Input

**Goal:** Allow users to speak shopping requests.

Tasks: - Select a suitable speech-to-text approach. - Add a microphone
interaction and permission/error states. - Convert speech to text and
let the user review or edit the transcript. - Pass the transcript
through the same request workflow used by typed input. - Test noisy,
incomplete, and long spoken requests.

**Acceptance criteria** - Users can submit a transcribed request through
the existing text workflow. - Users can review the transcript before
processing. - Denied permissions and transcription failures are handled
clearly.

### Milestone 8 --- Real Product Data Integration

**Goal:** Replace or supplement mock products with an appropriate real
catalogue.

Tasks: - Investigate available authorised APIs, feeds, or other
permitted integration methods. - Confirm terms, technical access, rate
limits, data freshness, and caching restrictions. - Implement a real
provider behind the product-provider abstraction. - Map source fields
into the application's product model. - Handle source failures, stale
prices, unavailable products, and incomplete data. - Add integration
tests and document source limitations.

**Acceptance criteria** - The integration method is technically and
contractually appropriate. - Source data is mapped and validated
consistently. - The system does not present unverified prices or
availability as guaranteed current facts. - The mock provider remains
usable for development and automated tests.

**Dependency:** This milestone depends on identifying a viable,
permitted product-data source. Makro integration is a target to
investigate, not an assumed available API.

### Milestone 9 --- Persistence, Security, and Deployment

**Goal:** Prepare the application for a controlled hosted environment
when the MVP justifies it.

Tasks: - Determine whether shopping sessions and preferences need
persistence. - Select and implement a SQL database if required. - Add
authentication and authorisation if supported user accounts or saved
data require them. - Review input validation, request limits, logging,
secret management, and error handling. - Restrict production CORS and
use HTTPS. - Add tests, monitoring, and operational documentation. -
Containerise the backend with Docker where useful. - Deploy to an
appropriate Azure configuration and verify the hosted workflow.

**Acceptance criteria** - Configuration and secrets are managed outside
source control. - Production origins and permissions are restricted to
what is required. - Data access is appropriately protected if
persistence and user accounts are introduced. - The deployed application
has documented setup, health checks, and known limitations. - Hosting
cost and service choices are understood before public release.

## 6. Prioritisation

---

Priority Work Reason

---

P0 Confirm Git checkpoint Protects the known-good
and foundation starting point.

P0 Product model and mock Provides the data
catalogue needed for search and
matching.

P0 Product retrieval and Establishes a testable
search API product capability.

P1 Shopping request Connects the user's
contract and UI/API intent to the backend
integration workflow.

P1 Structured AI Turns natural language
requirement extraction into machine-usable
constraints.

P1 Product matching and Delivers the core user
basket calculations value.

P1 End-to-end testing and Makes the MVP
documentation demonstrable and
maintainable.

P2 Voice input Enhances input after
the text flow works.

P2 Real product data Depends on a suitable
integration authorised source.

P2 Persistence, Docker, Introduced according to
Azure, and production requirements and
hardening readiness.

---

## 7. Out of Scope for the Initial MVP

The following are intentionally excluded until the core text-based
shopping journey is reliable:

- Autonomous checkout or purchase completion.
- Payment processing.
- Multi-agent architecture.
- Vector databases or retrieval-augmented generation without a
  demonstrated need.
- GraphQL without a justified API use case.
- Kubernetes.
- Complex personalisation and long-term memory.
- Advanced recommendation algorithms.
- Image recognition or computer vision.

## 8. Key Dependencies and Risks

---

Dependency or risk Impact Planned response

---

No confirmed retailer Real product Use mock data and
data source integration may be investigate permitted
delayed access separately.

LLM output may be Incorrect requirements Use structured outputs,
inaccurate or malformed or recommendations backend validation, and
deterministic business
logic.

Product prices or Misleading basket Track source and
availability may be totals freshness when
stale available; communicate
uncertainty.

Scope grows before the Delayed delivery Enforce milestone
MVP works acceptance criteria and
defer stretch features.

Secrets or permissive Security exposure Review configuration,
local settings reach secrets, host
production permissions, and CORS
before deployment.

Budget or quantity Unsatisfactory basket Surface trade-offs and
constraints conflict ask the user to decide
rather than silently
changing requirements.

---

## 9. Progress Tracking

For each milestone, record: - **Status:** Not started, In progress,
Blocked, or Complete. - **Owner:** Person responsible. -
**Dependencies:** Work that must be completed first. - **Acceptance
evidence:** Tests, screenshots, API responses, or a working demo. -
**Decisions and blockers:** Anything that changes scope or delivery.

A milestone should only be marked complete when its acceptance criteria
are met. The roadmap should be updated as implementation reveals new
constraints or changes the planned sequence.

## 10. Next Actions

1.  Confirm the working foundation is committed to Git.
2.  Create the `Product` model and mock product catalogue.
3.  Implement and test `GET /api/products`.
4.  Implement and test `GET /api/products/search`.
5.  Update the README and architecture document to reflect the new
    endpoints once they exist.
