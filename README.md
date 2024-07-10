# Tic-Tac-Tow

## Project Overview

"Tic-Tac-Tow" is a Unity project designed to showcase my updated skills after six months of focused learning and development. This implementation of the classic Tic-Tac-Toe game demonstrates the use of SOLID principles and key design patterns to create a clean, maintainable, and scalable codebase.

## SOLID Principles Demonstrated

1. **Single Responsibility Principle (SRP)**: Each class has a single responsibility, ensuring clarity and ease of maintenance.
2. **Open/Closed Principle (OCP)**: The code is open for extension but closed for modification, allowing new features to be added without altering existing code. Example, AIPlayer
3. **Liskov Substitution Principle (LSP)**: Subclasses can replace base classes without affecting functionality, ensuring robust and flexible code. Example, AIStrategy
4. **Interface Segregation Principle (ISP)**: The project uses several specific interfaces instead of one general-purpose interface, ensuring classes only implement necessary methods. Example, IPlayer
5. **Dependency Inversion Principle (DIP)**: High-level modules do not depend on low-level modules; both depend on abstractions, achieved through dependency injection. Example, GameManager manages IPlayer at interface level

## Design Patterns Used

- **Observer Pattern**: Utilized via Unity Events to handle game state changes, such as player moves and game over conditions.
- **Strategy Pattern**: Implemented for the AI brain, allowing different AI strategies to be selected at runtime.
