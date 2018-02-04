import client from './http-client'

class Api {

  getUsers() {
    return client.get('users');
  }

  saveUser(user) {
    return client.put('users', user);
  }

  deleteUser(id) {
    return client.delete(`users/${id}`);
  }

  getGroups() {
    return client.get('groups');
  }

  addGroup(group) {
    return client.put('groups', group);
  }

  deleteGroup(id) {
    return client.delete(`groups/${id}`);
  }
}

const api = new Api();

export default api;
