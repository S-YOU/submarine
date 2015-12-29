interface integer { }

declare module Submarine {
  interface Error {
    code: integer;
    name: string;
    message: string;
  }

  interface Config {
    version: string;
    webApiServerBaseUri: string;
  }

  interface User {
    id: integer;
    name: string;
  }

  interface Room {
    id: integer;
    battleServerBaseUri: string;
    members: User[];
  }

  type RoomKey = string;

  /** @noAuthRequired */
  function ping(message: string): { message: string; };
  /** @noAuthRequired */
  function signUp(name: string, password: string): { user: User; };
  /** @noAuthRequired */
  function login(name: string, password: string): { user: User; joinedRoom?: Room; };

  function findUser(name: string): { user?: User; };

  function createRoom(): { room: Room; roomKey: RoomKey; };
  function getRooms(): { rooms: Room[]; }
  function joinIntoRoom(room_id: integer): { roomKey: RoomKey; };

  module Battle {
    var ping: { message: string; }
  }
}
