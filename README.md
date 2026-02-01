# Task Management System – Low Level Design

## Overview
This project implements a clean and extensible Task Management System
using object-oriented design and SOLID principles.

## Features
- Create and manage tasks
- Assign tasks to users
- Priority and status management
- Valid state transitions
- Task filtering by user, status, and priority

## Design Highlights
- Rich domain model
- Business rules inside entities
- Repository abstraction
- Service orchestration layer

## Valid Status Flow
- Todo → InProgress
- InProgress → Blocked / Completed
- Blocked → InProgress

## Extensibility
- Add due dates
- Add comments
- Add task history / audit logs
- Persist using DB instead of memory

## How to Run
1. Open solution in Visual Studio
2. Run Program.cs
3. Modify scenarios for testing

## Author
Abhishek
